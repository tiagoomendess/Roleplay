using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkServer;
using GTANetworkShared;

namespace Roleplay
{
    class MapLocation : Script
    {

        private string name;
        private Vector3 location;
        private int icon;
        private Blip blip;

        public MapLocation(string name, Vector3 location, int icon)
        {

            this.name = name;
            this.location = location;
            this.icon = icon;

        }

        public void createBlip()
        {

            blip = API.createBlip(location);
            API.setBlipName(blip.handle, name);
            API.setBlipSprite(blip.handle, icon);

        }

        public void destroyBlip()
        {

            API.deleteEntity(blip.handle);

        }

        public void reloadBlip()
        {

            destroyBlip();
            createBlip();

        }

        public void setName(string name)
        {

            this.name = name;
            reloadBlip();

        }

        public void setLocation(Vector3 location)
        {

            this.location = location;
            reloadBlip();

        }

        public void setIcon(int icon)
        {

            this.icon = icon;
            reloadBlip();

        }

        public string getName() { return name; }

        public Vector3 getLocation() { return location; }

        public int getIcon() { return icon; }

    }
}
