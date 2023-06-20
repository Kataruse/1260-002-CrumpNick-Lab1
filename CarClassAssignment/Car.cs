using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarClassAssignment
{
    internal class Car
    {
        //attributes of Car's
        private string _make;
        private string _model;
        private int _year;
        private double _maxTankLevel;
        private double _currentTankLevel;
        private double _milesPerGallon;

        // below is getters and setters
        public string getMake()
        { 
            return _make; 
        }
        public string getModel()
        {
            return _model;
        }
        public int getYear() 
        {
            return _year;
        }
        public double getMaxTankLevel()
        {
            return _maxTankLevel;
        }
        public double getCurrentTankLevel()
        {
            return _currentTankLevel;
        }
        public double getMilesPerGallon()
        {
            return _milesPerGallon;
        }

        public void setMake(string make)
        {
            _make = make;
        }
        public void setModel(string model)
        {
            _model = model;
        }

        public void setYear(int year)
        {
            if (year >= 1900 && year <= DateTime.Now.Year)
            {
                _year = year;
            }
            else
            {
                _year = 2018;
            }
        }

        public void setMaxTankLevel(double maxTankLevel)
        {
            if (maxTankLevel > 0)
            {
                _maxTankLevel = maxTankLevel;
            }
            else
            {
                _maxTankLevel = 23;
            }
        }

        public void setCurrentTankLevel(double currentTankLevel)
        {
            if (currentTankLevel > 0)
            {
                _currentTankLevel = currentTankLevel;
            }
            else
            {
                _currentTankLevel = 18.5;
            }
        }

        public void setMilesPerGallon(double milesPerGallon)
        {
            if (milesPerGallon > 0)
            {
                _milesPerGallon = milesPerGallon;
            }
            else
            {
                _milesPerGallon = 21;
            }
        }
        
        // Car default constructor
        public Car()
        {
            setMake("Ford");
            setModel("F150");
            setYear(2018);
            setMaxTankLevel(23);
            setCurrentTankLevel(18.5);
            setMilesPerGallon(21);
        }

        // Car parameterized constuctor
        public Car(string make, string model, int year, double maxTankLevel, double currentTankLevel, double milesPerGallon)
        {
            setMake(make);
            setModel(model);
            setYear(year);
            setMaxTankLevel(maxTankLevel);
            setCurrentTankLevel(currentTankLevel);
            setMilesPerGallon(milesPerGallon);
        }

        // Car copy constuctor
        public Car(Car existingCar)
        {
            setMake(existingCar._make);
            setModel(existingCar._model);
            setYear(existingCar._year);
            setMaxTankLevel(existingCar._maxTankLevel);
            setCurrentTankLevel(existingCar._currentTankLevel);
            setMilesPerGallon(existingCar._milesPerGallon);
        }

        // method that takes the user input and adds it to the current tank if its greater than 0, and doesnt exceed the max tank level
        public string FillGasTank(double gallonsToFill)
        {
            if (gallonsToFill > 0)
            {
                if (gallonsToFill + _currentTankLevel <= _maxTankLevel)
                {
                    setCurrentTankLevel(gallonsToFill);
                    return $"{gallonsToFill} gallons was replenished to your tank.";
                }
                return $"{gallonsToFill} gallons is more than your max tank level or {_maxTankLevel} gallons.";
            }
            return $"{gallonsToFill} is less than 0.";
        }

        // method that checks to see if the distance put into the method can be driven
        private bool CanDriveDistance(double distance)
        {
            if (distance <= Math.Round(_milesPerGallon*_currentTankLevel, 2) && distance > 0)
            { 
                return true; 
            }
            else
            {
                return false;
            }
        }
        
        // method that removes the correct amount of gas that is used to drive the distance that was input
        public string Drive(double distance)
        {
            if (CanDriveDistance(distance))
            {
                _currentTankLevel = Math.Round(_currentTankLevel - distance / _milesPerGallon, 2);
                return $"You drove {distance} miles and used {Math.Round(distance / _milesPerGallon, 2)} gallons of gas.\nYour tank is now at {_currentTankLevel} gallons.";
            }
            else
            {
                return $"Not a valid distance entry.\nEnter a distance less than or equal to {Math.Round(_currentTankLevel * _milesPerGallon, 2)} and greater than 0.";
            }
        }
        
        // method that displays the created Car's attributes and current fuel level
        public string ToString()
        {
            return $"Make: {_make}\nModel: {_model}\nYear: {_year}\nMPG: {_milesPerGallon}\nCurrent Tank Level: {_currentTankLevel} out of {_maxTankLevel}";
        }
    }
}
