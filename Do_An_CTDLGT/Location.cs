using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn
{
    public class Location
    {
        public string ID;
        public float X;
        public float Y;
        public string Name;
        public string City;
        public string District;

        public string GetID()
        {
            return ID;
        }
        public float GetToaDoX()
        {
            return X;
        }
        public float GetToaDoY()
        {
            return Y;
        }
        public string GetName()
        {
            return Name;
        }
        public string GetCity()
        {
            return City;
        }
        public string GetDistrict()
        {
            return District;
        }
        public Location(string id, float x, float y, string name, string city, string district)
        {
            this.ID = id;
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.City = city;
            this.District = district;
        }
        public override string ToString()
        {
            return "Mã: " + ID + "\t||  Tọa độ (" + X + ", " + Y + ") \t||  Tên: " + Name + "\t||  Thành phố: " + City + "\t||  Quận: " + District;
        }
    }
}
