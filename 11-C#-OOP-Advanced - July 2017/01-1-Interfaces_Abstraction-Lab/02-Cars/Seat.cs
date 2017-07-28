﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Seat : ICar
    {
    private string model;
    private string color;

    public Seat(string model, string color)
        {
        this.Model = model;
        this.Color = color;
        }

    public string Model
        {
        get { return this.model; }
        private set { this.model = value; }
        }

    public string Color
        {
        get { return this.color; }
        private set { this.color = value; }
        }

    public string Start()
        {
        return "Engine start";
        }

    public string Stop()
        {
        return "Breaaak!";
        }

    public override string ToString()
        {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {this.GetType()} {this.Model}")
            .AppendLine(this.Start())
            .AppendLine(this.Stop());

        return sb.ToString().Trim();
        }
    }