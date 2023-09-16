using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Npgsql.HiLo.Repro;

public class Hello
{
    public int Id { get; set; }

    public class Configuration : IModelFinalizingConvention
    {
        public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
        {
            foreach ( var type in modelBuilder.Metadata.GetEntityTypes() )
            {
                if (type.GetProperty("Id") is { } id)
                {
                    id.SetHiLoSequenceName("hilo");
                }
            }
        }
    }
}