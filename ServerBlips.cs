using System;
using System.Collections.Generic;
using GTANetworkServer;
using GTANetworkShared;

namespace Roleplay
{
    class ServerBlips : Script
    {

        private static List<MapLocation> blipLocations = new List<MapLocation>()
        {

            { new MapLocation("Polícia", new Vector3(436.491, -982.172, 30.699), 188) },
            { new MapLocation("Oficina", new Vector3(-365.425, -131.809, 37.873), 72) },
            { new MapLocation("Oficina", new Vector3(-1143.113, -1988.581, 13.1637), 72) },
            { new MapLocation("Clube de Golf", new Vector3(-1336.715, 59.051, 55.246), 109) },
            { new MapLocation("Entrada Aeroporto", new Vector3(-969.059, -2798.559, 13.96455), 90) },
            { new MapLocation("Aeroporto - Partidas", new Vector3(-1037.332, -2736.591, 13.76129), 408) },
            { new MapLocation("Hospital", new Vector3(340.2387, -1395.851, 32.50924), 61) },
            { new MapLocation("Hospital", new Vector3(363.6537, -586.044, 28.68829), 61) },
            { new MapLocation("Universidade", new Vector3(-1628.27, 184.7169, 60.63145), 513) },
            { new MapLocation("Câmara Municipal", new Vector3(-540.7175, -211.1813, 37.6498), 411) },

        };

        public ServerBlips()
        {

            API.onResourceStart += initializeServerBlips;

        }

        public void initializeServerBlips()
        { 

            foreach (MapLocation mapLocation in blipLocations)
            {

                mapLocation.createBlip();

            }

        }

        public static List<MapLocation> getBlipByName(String blipName)
        {

            List<MapLocation> blips = new List<MapLocation>();

            foreach (MapLocation mapLocation in blipLocations)
            {

                if (mapLocation.getName().Equals(blipName))
                    blips.Add(mapLocation);

            }

            return blips;

        }

    }
}
