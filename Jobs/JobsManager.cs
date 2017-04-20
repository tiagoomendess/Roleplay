using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkServer;
using GTANetworkShared;

namespace Roleplay.Jobs
{
    class JobsManager : Script
    {

        private static double baseSalary = 505.00;
        private static double salaryDivision = 3.00;

        public enum Jobs
        {

            COP,
            GARBAGE_COLLECTOR,
            TAXI_DRIVER,
            BUS_DRIVER,
            TRUCK_DRIVER,
            PARAMEDIC,
            PRISION_GUARD,
            SOLDIER,
            PILOT

        }

        public JobsManager()
        {

            API.onClientEventTrigger += clientEventTrigger;

        }

        private void clientEventTrigger(Client player, string name, object[] args)
        {
            API.consoleOutput("Event received! name=" + name + " callback=" + args[0] + " action=" + args[1]);
            if (name == "menu_click")
            {

                if (args[0].Equals("police"))
                {

                    API.sendChatMessageToPlayer(player, "POLICE_ACTION = " + args[1]);

                }

            }

        }

        public static double calculateSalary(AbstractJob job)
        {

            return baseSalary * (job.getJobMultiplier() / salaryDivision);

        }

    }
}
