using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkServer;
using GTANetworkShared;

namespace Roleplay.Services
{
    class Hospital : AbstractService
    {

        private static string __serviceName = "Hospital";
        private static List<Vector3> __serviceLocations = new List<Vector3>()
        {

            { new Vector3(340.2387, -1395.851, 32.50924) },
            { new Vector3(363.6537, -586.044, 28.68829) },
            { new Vector3(-449.3866, -341.0368, 34.50178) },
            { new Vector3(1839.747, 3672.487, 34.27672) },
            { new Vector3(-247.3967, 6331.337, 32.62619) }

        };
        private static int __blipSprite = 61;

        public Hospital() : base(__serviceName, __serviceLocations, __blipSprite) {

            foreach (CylinderColShape colShape in collisionShapes)
            {

                colShape.onEntityEnterColShape += onEntityEnter;
                colShape.onEntityExitColShape += onEntityLeave;

            }

        }

        override public void onEntityEnter(ColShape shape, NetHandle entity)
        {

            Client player = API.getPlayerFromHandle(entity);

            if (player != null)
                API.triggerClientEvent(player, "create_menu", "hospital", "Hospital", "Escolha uma opção", false, 1, 
                    "Tratar Ferimentos", 
                    "Taxa Moderadora = 5€");

        }

        override public void onEntityLeave(ColShape shape, NetHandle entity)
        {

            Client player = API.getPlayerFromHandle(entity);

            if (player != null)
                API.triggerClientEvent(player, "destroy_menu");

        }

    }
}
