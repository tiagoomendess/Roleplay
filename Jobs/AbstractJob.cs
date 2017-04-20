using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkServer;
using GTANetworkShared;
using Roleplay.Services;

namespace Roleplay.Jobs
{
    abstract class AbstractJob : Script
    {

        protected JobsManager.Jobs jobType;
        protected int jobMultiplier = 1;
        protected List<Vector3> jobLocations;
        protected AbstractService service;

        public AbstractJob(JobsManager.Jobs jobType, int jobMultiplier, AbstractService service)
        {

            this.jobType = jobType;
            this.jobMultiplier = jobMultiplier;
            this.jobLocations = service.getServiceLocations();
            this.service = service;

        }

        public JobsManager.Jobs getJobType() { return jobType; }

        public int getJobMultiplier() { return jobMultiplier; }

        public List<Vector3> getJobLocations() { return jobLocations; }

        public AbstractService getJobService() { return service; }

        public abstract void startJobDay(Client player);

        public abstract void endJobDay(Client player);

    }
}
