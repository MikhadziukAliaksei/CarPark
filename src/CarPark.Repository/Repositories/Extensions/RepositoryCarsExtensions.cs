using CarPark.Entities.Models;
using System;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;

namespace CarPark.Repository.Repositories.Extensions
{
    public static class RepositoryCarsExtensions
    {
        public static IQueryable<Car> FilterCars(this IQueryable<Car> cars, uint minYear, uint maxYear) =>
            cars.Where(e => (e.YearOfIssue >= minYear && e.YearOfIssue <= maxYear));

        public static IQueryable<Car> Search(this IQueryable<Car> cars, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return cars;
            }

            var loweCaseTerm = searchTerm.Trim().ToLower();

            return cars.Where(e => e.Model.ToLower().Contains(loweCaseTerm));
        }

        public static IQueryable<Car> Sort(this IQueryable<Car> cars, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return cars.OrderBy(e => e.Mark);
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Car).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var orderQueryBulider = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    continue;
                }
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                {
                    continue;
                }

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBulider.Append($"{objectProperty.Name.ToString()} {direction},");
            }
            var orderQuery = orderQueryBulider.ToString().TrimEnd(',',' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                return cars.OrderBy(e => e.Mark);
            }

            return cars.OrderBy(orderQuery);
        }
    }
}
