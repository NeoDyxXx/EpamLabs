using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aircompany.Utils
{
    public static class PlanesUtils
    {
        public static bool IsListMilitaryPlaneHaveATransportType(List<Planes.MilitaryPlane> militaryPlanes)
        {
            return militaryPlanes.Any(plane => plane.GetPlaneType() == Models.MilitaryType.TRANSPORT);
        }

        public static bool IsListPlanesSortedByMaxLoadCapacity(List<Planes.Plane> planes)
        {
            bool nextPlaneMaxLoadCapacityIsHigherThanCurrent = true;

            for (int i = 0; i < planes.Count - 1; i++)
            {
                Planes.Plane currentPlane = planes[i];
                Planes.Plane nextPlane = planes[i + 1];
                if (currentPlane.MaxLoadCapacity() > nextPlane.MaxLoadCapacity())
                {
                    nextPlaneMaxLoadCapacityIsHigherThanCurrent = false;
                }
            }

            return nextPlaneMaxLoadCapacityIsHigherThanCurrent;
        }
    }
}
