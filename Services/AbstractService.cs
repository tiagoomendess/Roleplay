using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkServer;
using GTANetworkShared;

namespace Roleplay.Services
{
    abstract class AbstractService : Script
    {

        protected string serviceName;
        protected List<Vector3> serviceLocations;
        protected List<CylinderColShape> collisionShapes = new List<CylinderColShape>();
        protected bool hasBlip;

        public AbstractService(string serviceName, List<Vector3> serviceLocations)
        {

            this.serviceName = serviceName;
            this.serviceLocations = serviceLocations;
            hasBlip = false;

            createCollisionShapes();
            
        }

        public AbstractService(string serviceName, List<Vector3> serviceLocations, int blipSprite)
        {

            this.serviceName = serviceName;
            this.serviceLocations = serviceLocations;
            hasBlip = true;

            createCollisionShapes();
            createBlip(blipSprite);

        }

        private void createBlip(int blipSprite)
        {

            foreach (Vector3 location in serviceLocations)
            {

                Blip serviceBlip = API.createBlip(location);
                API.setBlipSprite(serviceBlip.handle, blipSprite);
                API.setBlipName(serviceBlip.handle, serviceName);

            }

        }

        private void createCollisionShapes()
        {

            foreach (Vector3 location in serviceLocations)
            {

                CylinderColShape colShape = API.createCylinderColShape(location, 2, 3);
                API.createMarker(1, location - new Vector3(0, 0, 1), new Vector3(), new Vector3(),
                    new Vector3(1, 1, 1), 100, 255, 255, 255);
                collisionShapes.Add(colShape);

            }

        }

        public List<Vector3> getServiceLocations() { return serviceLocations; }

        public abstract void onEntityEnter(ColShape shape, NetHandle entity);

        public abstract void onEntityLeave(ColShape shape, NetHandle entity);

    }
}
