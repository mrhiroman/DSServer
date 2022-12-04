using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DSServer
{
    internal class Player
    {
        public int id;
        public string username;

        public Vector3 position;
        public Quaternion rotation;

        public Player(int _id, string _username, Vector3 _spawnPosition)
        {
            id = _id;
            username = _username;
            position = _spawnPosition;
        }
    }
}
