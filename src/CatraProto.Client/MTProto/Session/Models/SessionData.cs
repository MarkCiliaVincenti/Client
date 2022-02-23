using System;
using CatraProto.Client.MTProto.Session.Exceptions;
using CatraProto.Client.MTProto.Session.Interfaces;
using CatraProto.TL;

namespace CatraProto.Client.MTProto.Session.Models
{
    class SessionData : SessionModel, IDisposable
    {
        private const int SupportedSessionVersion = 1;
        public Authorization Authorization { get; }
        public AuthorizationKeys AuthorizationKeys { get; }
        public UpdatesStates UpdatesStates { get; }
        public RandomId RandomId { get; }
        private int _sessionVersion;

        public SessionData(object mutex) : base(mutex)
        {
            UpdatesStates = new UpdatesStates(Mutex);
            Authorization = new Authorization(Mutex);
            AuthorizationKeys = new AuthorizationKeys(Mutex);
            RandomId = new RandomId(mutex);
        }

        private void EnsureVersion()
        {
            if (_sessionVersion > SupportedSessionVersion)
            {
                throw new SessionDeserializationException($"Deserialization failed: the session has been serialized by a newer version of CatraProto ({_sessionVersion} > {SupportedSessionVersion})");
            }
            else if (_sessionVersion < SupportedSessionVersion)
            {
                throw new SessionDeserializationException($"Deserialization failed: the session has been serialized by an older version of CatraProto ({_sessionVersion} < {SupportedSessionVersion})");
            }
        }

        public void Read(Reader reader)
        {
            lock (Mutex)
            {
                _sessionVersion = reader.Read<int>();
                EnsureVersion();
                Authorization.Read(reader);
                AuthorizationKeys.Read(reader);
                UpdatesStates.Read(reader);
                RandomId.Read(reader);
            }
        }

        public void Save(Writer writer)
        {
            lock (Mutex)
            {
                writer.Write(1);
                Authorization.Save(writer);
                AuthorizationKeys.Save(writer);
                UpdatesStates.Save(writer);
                RandomId.Save(writer);
            }
        }

        public new void RegisterOnUpdated(Action<SessionModel> action)
        {
            UpdatesStates.RegisterOnUpdated(action);
            Authorization.RegisterOnUpdated(action);
            AuthorizationKeys.RegisterOnUpdated(action);
        }

        public void Dispose()
        {
            Authorization.Dispose();
        }
    }
}