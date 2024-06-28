using LINQDataContext;

namespace ExerciceDeLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContext dc = new DataContext();

            #region Faites vos exos ici

            /* 2.1
            //var result = dc.Students.Select(
            //    s => new {
            //        Nom = s.Last_Name,
            //        DateDeNaissance = s.BirthDate,
            //        s.Login,
            //        ResultatAnnuel = s.Year_Result
            //    }
            //    ); 
            var result = from s in dc.Students
                select  new {
                    Nom = s.Last_Name,
                    DateDeNaissance = s.BirthDate,
                    s.Login,
                    ResultatAnnuel = s.Year_Result
                };
            */

            /* 2.2 

            var result = dc.Students.Select(s => new
            {
                NomComplet = s.Last_Name + " " + s.First_Name,
                Id = s.Student_ID,
                DateDeNaissance = s.BirthDate//.ToShortDateString()
            });
            */

            /* 2.3

            IEnumerable<string> result = dc.Students.Select(s => $"{s.Student_ID}|{s.First_Name}|{s.Last_Name}|{s.BirthDate}|{s.Login}|{s.Section_ID}|{s.Year_Result}|{s.Course_ID}");
            */

            /* 3.1

            var result = dc.Students.Where(s => s.BirthDate.Year < 1955)
                .Select(s => new { 
                    Nom = s.Last_Name,
                    ResultatAnnuel = s.Year_Result,
                    Status = (s.Year_Result >= 12)? "OK" : "KO"}
                );
            */

            /* 3.2 */

            var result = dc.Students.Where(s => s.BirthDate.Year >= 1955 && s.BirthDate.Year <= 1965)
                .Select(s => new { 
                    Nom = s.Last_Name,
                    ResultatAnnuel = s.Year_Result,
                    Categorie = s.Year_Result < 10 ? "inférieur" :
                                s.Year_Result == 10 ? "neutre" :
                                "supérieur",
                    //CategorieSwitch = s.Year_Result switch
                    //{
                    //    10 => "neutre",
                    //    _ when s.Year_Result < 10 => "inférieur",
                    //    _ => "supérieur"

                    //}
                }
                );
            

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            #endregion

            #region Console.ReadLine()
            Console.ReadLine();
            #endregion
        }
    }
}