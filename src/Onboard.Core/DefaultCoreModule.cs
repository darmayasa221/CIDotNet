using Autofac;
// using basic.Core.Interfaces;
// using basic.Core.Services;

namespace Onboard.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    // builder.RegisterType<ToDoItemSearchService>()
    //     .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
