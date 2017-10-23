using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HmrcDotNet.Web.Data.Model;

namespace HmrcDotNet.Web.Data.Seed
{
    public static class SeedIndividual
    {
        public static async Task SeedData(ApplicationDbContext context)
        {
            var list = GetIndividual();
            foreach (var item in list)
            {
                var exists = context.Individuals.Any(o => o.IndividualId == item.IndividualId);
                if (!exists)
                {
                    context.Individuals.Add(item);
                }
                await context.SaveChangesAsync();
            }

        }

        public static List<Individual> GetIndividual()
        {
            var model = new List<Individual>();
            model.Add(new Individual(){IndividualId = SeedProp.Individual1,IndividualName = "Test1"});
            model.Add(new Individual(){IndividualId = SeedProp.Individual2,IndividualName = "Test2"});
            return model;
        }
    }
}
