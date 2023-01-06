using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NetclinicWebApi.Helpers
{
    public class SqlHelper
    {
        public string BuildEFConnection(string shortConnectionString)
        {
            return ConfigurationManager.ConnectionStrings["AzureSQLPetclinicEntities1"].ConnectionString;

            return $"metadata=res://*/Models.petclinic.csdl|res://*/Models.petclinic.ssdl|res://*/Models.petclinic.msl;" +
                $"provider=System.Data.SqlClient;" +
                $"provider connection string=\"{shortConnectionString}" +
                $"multipleactiveresultsets=True;application name=EntityFramework\"";
            //// Specify the provider name, server and database. 
            //string providerName = "System.Data.SqlClient";

            //// Initialize the connection string builder for the 
            //// underlying provider taking the short connection string.
            //SqlConnectionStringBuilder sqlBuilder =
            //    new SqlConnectionStringBuilder(shortConnectionString);

            //// Set the properties for the data source.
            //sqlBuilder.IntegratedSecurity = false;

            //// Build the SqlConnection connection string. 
            //string providerString = sqlBuilder.ToString();

            //// Initialize the EntityConnectionStringBuilder.
            //EntityConnectionStringBuilder entityBuilder =
            //    new EntityConnectionStringBuilder();

            ////Set the provider name.
            //entityBuilder.Provider = providerName;

            //// Set the provider-specific connection string.
            //entityBuilder.ProviderConnectionString = providerString;

            //// Set the Metadata location.
            ////entityBuilder.Metadata = String.Format("res://*/Application.{0}.Data.Model.{0}Model.csdl|res://*/Application.{0}.Data.Model.{0}Model.ssdl|res://*/Application.{0}.Data.Model.{0}Model.msl", "myConnection");
            //entityBuilder.Metadata = "//*/Models.petclinic.csdl|res://*/Models.petclinic.ssdl|res://*/Models.petclinic.msl";
            //return entityBuilder.ToString();
        }

    }
}