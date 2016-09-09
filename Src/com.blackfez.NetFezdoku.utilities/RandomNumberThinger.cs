using System;

namespace com.blackfez.NetFezdoku.utilities
{
    public sealed class RandomNumberThinger
    {
        private static volatile RandomNumberThinger _instance;
        private static readonly object SyncRoot = new object();
        private static Random _rng;

        private RandomNumberThinger()
        {
            _rng = new Random();
        }

        public static RandomNumberThinger Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock( SyncRoot )
                {
                    if( _instance == null )
                    {
                        _instance = new RandomNumberThinger();
                    }
                }
                return _instance;
            }
        }

        public int PickAValue( int count )
        {
            return _rng.Next(0, count);
        } 
    }
}
