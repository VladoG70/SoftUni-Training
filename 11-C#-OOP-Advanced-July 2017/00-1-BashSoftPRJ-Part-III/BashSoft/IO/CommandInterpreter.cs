using BashSoft.Exceptions;
using BashSoft.IO.Commands;
using System;
using System.Linq;
using System.Reflection;
using BashSoft.Attributes;
using BashSoft.Contracts;

namespace BashSoft
    {
    public class CommandInterpreter : IInterpreter
        {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
            {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
            }

        public void InterpredCommand(string input)
            {
            string[] data = input.Split(' ');

            string commandName = data[0];
            // All Commands-name must to be lowercase
            commandName = commandName.ToLower();

            try
                {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
                }
            catch (Exception e)
                {
                OutputWriter.DisplayException(e.Message);
                }
            }

        private IExecutable ParseCommand(string input, string command, string[] data)
            {
            object[] parametersForConstruction = new object[]
            {
                input,
                data
            };

            Type typeOfCommand = Assembly
            .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(type => type.GetCustomAttributes(typeof(AlliasAttribute))
                                            .Where(atr => atr.Equals(command)).ToArray().Length > 0);

            if (typeOfCommand == null)
                {
                throw new InvalidCommandException(command);
                }

            Type typeOfInterpreter = typeof(CommandInterpreter);
            Command exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
                {
                Attribute injAtr = fieldOfCommand.GetCustomAttribute(typeof(InjectAttribute));

                if (injAtr != null)
                    {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == fieldOfCommand.FieldType))
                        {
                        fieldOfCommand.SetValue(exe, fieldsOfInterpreter.First(x => x.FieldType == fieldOfCommand.FieldType).GetValue(this));
                        }
                    }
                }

            return exe;
            }
        }
    }