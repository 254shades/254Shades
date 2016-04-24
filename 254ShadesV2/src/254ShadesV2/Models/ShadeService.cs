using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.OptionsModel;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _254ShadesV2.Models
{
    public class ShadeService : IShadeService
    {
        string tableUri = string.Empty;
        public ShadeService(IOptions<ShadeServiceConfiguration> configuration)
        {
            //tableUri = configuration["MicrosoftAzureStorage:TableUri"];
            tableUri = configuration.Value.TableUri;
        }

        public async Task<IQueryable<IShade>> GetShadesAsync()
        {
            CloudTable table = new CloudTable(new Uri(tableUri));
            var typedQuery = new TableQuery<Shade>();

            List<IShade> returnValue = new List<IShade>();

            TableContinuationToken token = null;
            do
            {
                var result = await table.ExecuteQuerySegmentedAsync(typedQuery, token);
                token = result.ContinuationToken;
                returnValue.AddRange(result.Results);
            } while (token != null);

            return returnValue.AsQueryable();
        }

        public async Task<IShade> SaveShadeAsync(IShade shade)
        {
            Shade convertedShade = shade as Shade;
            if (convertedShade == null) throw new ArgumentException("Shade is either null or wrong type");

            CloudTable table = new CloudTable(new Uri(tableUri));

            var result = await table.ExecuteAsync(TableOperation.InsertOrMerge(convertedShade));
            return convertedShade;
        }
    }

    public class ShadeServiceConfiguration
    {
        public string TableUri { get; set; }
    }

    public interface IShadeService
    {
        Task<IQueryable<IShade>> GetShadesAsync();
        Task<IShade> SaveShadeAsync(IShade shade);
    }
}
