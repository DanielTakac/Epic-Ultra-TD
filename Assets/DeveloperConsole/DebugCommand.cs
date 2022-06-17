using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class DebugCommandBase{

    private string _commandId;
    private string _commandDescription;
    private string _commandFormat;
    
    public string commandId { get { return _commandId; } }
    public string commandDescription {  get { return _commandDescription; } }
    public string commandFormat { get { return _commandFormat; } }

    public DebugCommandBase(string id, string description, string format){

        _commandId = id;
        _commandDescription = description;
        _commandFormat = format;

    }

}

public class DebugCommand : DebugCommandBase{

    private System.Action<string> command;

    public DebugCommand(string id, string description, string format, System.Action<string> command) : base(id, description, format){

        this.command = command;

    }

    public void Invoke(string parameter = ""){

        command.Invoke(parameter);

    }

}
