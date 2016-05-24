using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.blackfez.NetFezdoku.utilities
{
    public sealed class RandomNumberThinger
    {
        private static volatile RandomNumberThinger _Instance;
        private static object syncRoot = new object();
        private static Random Rng;

        private RandomNumberThinger()
        {
            Rng = new Random();
        }

        public static RandomNumberThinger Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock( syncRoot )
                    {
                        if( _Instance == null )
                        {
                            _Instance = new RandomNumberThinger();
                        }
                    }
                }
                return _Instance;
            }
        }

        public int PickAValue( int count )
        {
            return Rng.Next(1, count);
        } 
    }
}
