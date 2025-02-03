using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Application.Core.Domain
{
    public class Plane
    {

        public Plane() { }

        public Plane(int capacity)
        {
            Capacity = capacity;
        }

        public Plane(int capacity, DateTime manufactureDate, int planeId, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneId = planeId;
            PlaneType = planeType;
        }
        #region java
        //private int Capacity;

        //public int GetCapacity() {  return Capacity; }
        //public void SetCapacity(int capacity) { Capacity = capacity; }
        #endregion
        //public int Capacity { get; set; }//pop light version
        //public int capacity { get; private set; }
        //private int myVar;

        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }
        public IList<Flight> flights { get; set; }

        public override string ToString()
        {
            return "Capacity : " + Capacity + " ManufactureDate : " + ManufactureDate + " PlaneId : " + PlaneId + " PlaneType : " + PlaneType;
        }
    }
}
