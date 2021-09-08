using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class D010
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D011
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D012
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D015
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D016
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D017
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D018
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D021
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D029
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D02A
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D01D
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D009
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D106
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D001
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D107
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D00A
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D119
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D1A0
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D1A1
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D000
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D023
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D024
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D11F
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D120
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D145
{
    public string v { get; set; }
    public string u { get; set; }
}

public class D027
{
    public string v { get; set; }
    public string u { get; set; }
}

public class Data
{
    public D010 D010 { get; set; }
    public D011 D011 { get; set; }
    public D012 D012 { get; set; }
    public D015 D015 { get; set; }
    public D016 D016 { get; set; }
    public D017 D017 { get; set; }
    public D018 D018 { get; set; }
    public D021 D021 { get; set; }
    public D029 D029 { get; set; }
    public D02A D02A { get; set; }
    public D01D D01D { get; set; }
    public D009 D009 { get; set; }
    public D106 D106 { get; set; }
    public D001 D001 { get; set; }
    public D107 D107 { get; set; }
    public D00A D00A { get; set; }
    public D119 D119 { get; set; }
    public D1A0 D1A0 { get; set; }
    public D1A1 D1A1 { get; set; }
    public D000 D000 { get; set; }
    public D023 D023 { get; set; }
    public D024 D024 { get; set; }
    public D11F D11F { get; set; }
    public D120 D120 { get; set; }
    public D145 D145 { get; set; }
    public D027 D027 { get; set; }
    public string gid { get; set; }
    public string tid { get; set; }
    public DateTime timestamp { get; set; }
    public Data data { get; set; }
}

public class Statuss
{
    public int code { get; set; }
    public string msg { get; set; }
}

public class Roots
{
    public string @is { get; set; }
    public string ver { get; set; }
    public IList<Data> data { get; set; }
    public int count { get; set; }
    public Statuss statuss { get; set; }
}