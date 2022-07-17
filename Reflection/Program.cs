using System.Reflection;
using System.Text;

namespace Reflection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Assembly testAssembly = Assembly.LoadFile(@"D:\Users\eliel\Downloads\TopCoders\repos\Reflection\Reflection\bin\Debug\net6.0\Reflection.dll");
            Type studentType = testAssembly.GetType("Reflection.Student");
            Object student1 = Activator.CreateInstance(studentType);
            PropertyInfo nameType = studentType.GetProperty("Name");
            nameType.SetValue(student1, "Eliel Rodrigues", null);
            PropertyInfo universityType = studentType.GetProperty("University");
            universityType.SetValue(student1, "Let's University", null);
            PropertyInfo rollType = studentType.GetProperty("RollNumber");
            rollType.SetValue(student1, 12345, null);
            MethodInfo methodInfo = studentType.GetMethod("DisplayInfo");
            ParameterInfo[] parameters = methodInfo.GetParameters();
            var result =methodInfo.Invoke(student1, parameters);
        }
        public void DisplayPublicProperties(Object obj)
        {
            var type = obj.GetType();
            var builder = new StringBuilder();
            builder.AppendLine("Data do Log:" + DateTime.Now.ToString());
            
            foreach (var p in type.GetProperties())
            {
                builder.AppendLine(p.Name + " " + p.GetValue(obj));
            }
            Console.WriteLine(builder);
        }
    }
}