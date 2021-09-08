using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Flags
{
    public bool accountActivated { get; set; }
    public bool acceptedTermsAndConditions { get; set; }
    public bool acceptedDataPrivacyTerms { get; set; }
    public bool resetPassword { get; set; }
}

public class Logindata
{
    public string uid { get; set; }
    public Flags flags { get; set; }
    public List<string> roles { get; set; }
    public string authorization { get; set; }
}

public class Status
{
    public int code { get; set; }
    public string msg { get; set; }
}

public class Root
{
    public Logindata logindata { get; set; }
    public Status status { get; set; }
}


