using System.IO;
using System.Linq;
using reto1.Bl;

namespace reto1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool o;

            //1º Reads and maps each line of the file into the InputClas object
            var inputList = from line in File.ReadAllLines(args[0])
                            let columns = line.Split(';')
                            select new InputClass()
                            {
                                Codigo = int.Parse(columns[0]),
                                Ax = bool.TryParse(columns[1], out o),
                                Ay = bool.TryParse(columns[2], out o),
                                Bx = bool.TryParse(columns[3], out o),
                                By = bool.TryParse(columns[4], out o)
                            };

            //2º Convert
            var output = Conversor.Convert(inputList.ToList());

            //3º Write the result
            File.Create("Data/output.csv").Dispose();
            var fileStream = new FileStream("Data/output.csv", FileMode.Create, FileAccess.Write);
            var streamWriter = new StreamWriter(fileStream);

            foreach (var outputClass in output)
            {
                var s = string.Format("{0};{1};{2}", outputClass.X, outputClass.Y, outputClass.ClassAB);
                streamWriter.WriteLine(s);
            }

            streamWriter.Close();
        }
    }
}
