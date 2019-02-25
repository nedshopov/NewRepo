using System;
using System.Collections.Generic;
using TestWorkTask.Business.Commands;
using TestWorkTask.Business.DependencyInjection;

namespace TestWorkTask.Business
{
   /// <summary>
   /// Dictionary of command handlers. This substitutes a proper implementation of CQRS pattern, while still maintaining some core OOP princples.
   /// </summary>
   public static class HandlersDictionary
   {
      /// <summary>
      /// A dictionary of commands and command handelrs.
      /// </summary>
      public static IDictionary<Type, Type> commandHandlers;

      /// <summary>
      /// Get a command handler from the IoC container for the specific command.
      /// </summary>
      /// <typeparam name="TCommand"></typeparam>
      /// <param name="commandType"></param>
      /// <returns></returns>
      public static ICommandHandler<TCommand> GetHandlerForCommandType<TCommand>(TCommand commandType) where TCommand : ICommand
      {
         Type handlerType = commandHandlers[commandType.GetType()];
         var commandHandler = SystemObjectFactory.Container.GetInstance(handlerType);
         return commandHandler as ICommandHandler<TCommand>;
      }

      public static void Add(Type command, Type handler)
      {
         if(commandHandlers == null)
         {
            commandHandlers = new Dictionary<Type, Type>();
         }
         commandHandlers.Add(command, handler);
      }

      public static void PopulateHandlersDictionary()
      {
         Add(typeof(GetAllProductsCommand), typeof(ICommandHandler<GetAllProductsCommand>));
         Add(typeof(GetNewShoppingCartCommand), typeof(ICommandHandler<GetNewShoppingCartCommand>));
         Add(typeof(GetShoppingCartCommand), typeof(ICommandHandler<GetShoppingCartCommand>));
         Add(typeof(AddItemToShoppingCartCommand), typeof(ICommandHandler<AddItemToShoppingCartCommand>));
         Add(typeof(RemoveItemFromShoppingCartCommand), typeof(ICommandHandler<RemoveItemFromShoppingCartCommand>));
      }
   }
}
