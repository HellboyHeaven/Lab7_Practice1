using ReflectionTutorial;
using System.Reflection;

var data = File.ReadAllText("car.txt").Split(";");
var brand = data[0];
var model = data[1];
var tankCapacity = int.Parse(data[2]);
var fuelConsumption = double.Parse(data[3]);
var fuelLevel = int.Parse(data[4]);
var odometer = int.Parse(data[5]);

//To do on your own 4
var carType = typeof(Car);
var carobj = Activator.CreateInstance(carType, brand, model, tankCapacity, fuelConsumption);

var fuelLevelField = carType.GetField("_fuelLevel", BindingFlags.NonPublic | BindingFlags.Instance);
var odometerField = carType.GetField("_odometer", BindingFlags.NonPublic | BindingFlags.Instance);

fuelLevelField.SetValue(carobj, fuelLevel);
odometerField.SetValue(carobj, odometer);

Car car = (Car)carobj;

Console.WriteLine($"{car.Brand} {car.Model} drove {car.Odometer} kilometers and remaining fuel is {car.FuelLevel}");
