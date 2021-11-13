using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        public MilitaryType typeOfPlane { get; set; }

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType typeOfPlane)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            this.typeOfPlane = typeOfPlane;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   typeOfPlane == plane.typeOfPlane;
        }

        public override int GetHashCode()
        {
            return 1701194404 + base.GetHashCode() + typeOfPlane.GetHashCode();
        }

        public MilitaryType GetPlaneType()
        {
            return typeOfPlane;
        }


        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + typeOfPlane +
                    '}');
        }        
    }
}
