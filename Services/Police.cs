using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkServer;
using GTANetworkShared;
using Roleplay.Jobs;

namespace Roleplay.Services
{
    class Police : AbstractService
    {

        private static string __serviceName = "Polícia";
        private static List<Vector3> __serviceLocations = new List<Vector3>()
        {

            { new Vector3(441.1989, -981.4964, 30.68958) },

        };
        private static int __blipSprite = 188;

        public Police() : base(__serviceName, __serviceLocations, __blipSprite)
        {

            foreach (CylinderColShape colShape in collisionShapes)
            {

                colShape.onEntityEnterColShape += onEntityEnter;
                colShape.onEntityExitColShape += onEntityLeave;

            }

        }

        public override void onEntityEnter(ColShape shape, NetHandle entity)
        {

            Client player = API.getPlayerFromHandle(entity);

            if (player != null)
            {

                if (API.hasEntityData(entity, "JOB"))
                {

                    if (API.getEntityData(entity, "JOB") == JobsManager.Jobs.COP)
                    {

                        API.triggerClientEvent(player, "create_menu", "police", "Polícia", "Escolha uma opção", false, 1,
                            "Trabalhar");

                        return;

                    }

                }

                API.triggerClientEvent(player, "create_menu", "police", "Polícia", "Escolha uma opção", false, 3,
                        "Inscrever na academia", "Pagar Multa", "Pagar Caução",
                        "Inscreve-te na academia da polícia", "Pagas as tuas multas", "Pagas a caução para poderes sair em liberdade");

            }

        }

        public override void onEntityLeave(ColShape shape, NetHandle entity)
        {

            Client player = API.getPlayerFromHandle(entity);

            if (player != null)
                API.triggerClientEvent(player, "destroy_menu");

        }

    }
}
