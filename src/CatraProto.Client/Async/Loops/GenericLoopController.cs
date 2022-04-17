using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using CatraProto.Client.Async.Loops.Bodies;
using CatraProto.Client.Async.Loops.Enums.Generic;
using CatraProto.Client.Async.Signalers;
using Serilog;

namespace CatraProto.Client.Async.Loops
{
    public class GenericLoopController : LoopController<GenericLoopState, GenericSignalState>
    {
        public GenericLoopController(ILogger logger) : base(new AsyncStateSignaler<SignalBody<GenericSignalState>>(null), GenericLoopState.NotYetStarted, logger.ForContext<GenericLoopController>())
        {
        }

        public override bool SendSignal(GenericSignalState genericSignal, [MaybeNullWhen(false)] out Task signalHandledTask)
        {
            signalHandledTask = null;
            lock (SharedLock)
            {
                if (LoopImplementation is null)
                {
                    return false;
                }

                if (LoopState is GenericLoopState.Stopped or GenericLoopState.Faulted)
                {
                    return false;
                }

                var lastState = StateSignaler.GetLastSignaled();
                switch (genericSignal)
                {
                    //if the sender wants to signal Start, then the last state must be null because that would mean that nothing else has happened before
                    case GenericSignalState.Start when lastState is not null:
                    //if the sender wants to signal Stop, then the last state must not be null and it can't be if Start has been sent before
                    case GenericSignalState.Stop when lastState is null:
                        return false;
                    default:
                        switch (genericSignal)
                        {
                            case GenericSignalState.Start:
                                StateSignaler.Signal(SignalBody<GenericSignalState>.FromSignal(genericSignal, out signalHandledTask));
                                LaunchLoop();
                                break;
                            case GenericSignalState.Stop:
                                StateSignaler.Signal(SignalBody<GenericSignalState>.FromSignal(genericSignal, ShutdownSource));
                                signalHandledTask = ShutdownSource.Task;
                                CancellationTokenSource.Cancel();
                                break;
                            default:
                                throw new InvalidOperationException("Unreachable");
                        }

                        return true;
                }
            }
        }

        protected override void LoopFaulted(Exception e)
        {
            lock (SharedLock)
            {
                if (!IsOnFaultedSubscribed())
                {
                    Logger.Error(e, "Exception thrown while running on loop {Impl}", LoopImplementation!);
                }

                LoopState = GenericLoopState.Faulted;
                ClearSignals();
                OnStopped();
                TriggerFaulted(e);
            }
        }

        protected override void SetLoopState(GenericLoopState state)
        {
            lock (SharedLock)
            {
                LoopState = state;
                switch (state)
                {
                    case GenericLoopState.Stopped:
                        OnStopped();
                        break;
                    case GenericLoopState.Faulted:
                    case GenericLoopState.NotYetStarted:
                        throw new ArgumentOutOfRangeException(state.ToString(), "This state can't be manually set by the loop");
                }
            }
        }
    }
}