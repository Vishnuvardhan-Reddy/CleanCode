public class Temperature
{
    public double Value { get; }
 
    public Temperature(double value)
    {
        if (value < 34 || value > 42)
            throw new ArgumentException("Invalid temperature");
        Value = value;
    }
}
 
public class BloodPressure
{
    public int Systolic { get; }
    public int Diastolic { get; }
 
    public BloodPressure(int systolic, int diastolic)
    {
        if (systolic < 70 || systolic > 200)
            throw new ArgumentException("Invalid systolic BP");
        if (diastolic < 40 || diastolic > 120)
            throw new ArgumentException("Invalid diastolic BP");
        if (diastolic > systolic)
            throw new ArgumentException("Diastolic cannot exceed systolic");
 
        Systolic = systolic;
        Diastolic = diastolic;
    }
}
 
public class HeartRate
{
    public int Value { get; }
 
    public HeartRate(int value, int age)
    {
        int maxHeartRate = 220 - age;
        if (value < 40 || value > maxHeartRate * 1.2)
            throw new ArgumentException($"Heart rate invalid for age {age}");
 
        Value = value;
    }
}
 
public class BloodType
{
    private static readonly string[] ValidBloodTypes = { "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-" };
    public string Type { get; }
 
    public BloodType(string type)
    {
        if (!ValidBloodTypes.Contains(type))
            throw new ArgumentException("Invalid blood type");
        Type = type;
    }
}
 
public class LastMeal
{
    public DateTime LastMealTime { get; }
 
    public LastMeal(DateTime lastMealTime)
    {
        LastMealTime = lastMealTime;
    }
 
    public bool IsRecentMeal() => (DateTime.Now - LastMealTime).TotalHours < 2;
}
 

public class PatientVitalsService
{
    public void RecordVitals(
        int patientId,
        Temperature temperature,
        BloodPressure bloodPressure,
        HeartRate heartRate,
        BloodType bloodType,
        int age,
        LastMeal lastMeal)
    {
        // Meal timing affects blood pressure readings
        if (lastMeal.IsRecentMeal() && bloodPressure.Diastolic > 90)
        {
            TriggerAlert("Elevated postprandial blood pressure");
        }
    }
 
    private void TriggerAlert(string message)
    {
        Console.WriteLine($"ALERT: {message}");
    }
}


// we can use this class to simplify the parameters for the RecordVitals
public class PatientInfo
{
    public Temperature Temperature { get;}
    public BloodPressure BloodPressure { get; }
    public HeartRate HeartRate {get; }
    public BloodType BloodType { get; }
    public LastMeal LastMeal { get; }

    public PatientInfo(Temperature temperature, BloodPressure bloodPressure,HeartRate heartRate, BloodType bloodType, LastMeal lastMeal)
    {
        Temperature = temperature;
        BloodPressure = bloodPressure;
        HeartRate = heartRate;
        BloodType = bloodType;
        LastMeal = lastMeal;
    }
}
