﻿namespace CommLib
{
    public class TrackerClientFactory
    {
        private static GrpcTrackerClient? _instance;
        public static GrpcTrackerClient Create(string address, int port)
        {
            if (_instance == null)
            {
                _instance = new GrpcTrackerClient(address,port);
            }
            return _instance;
        }

        public static GrpcTrackerClient Update(string address, int port)
        {
            _instance?.Dispose();
            _instance = null;
            return Create(address, port);
        }
    }
}
