using System;
using UnityEngine;

public class Cards
{
    public static explicit operator int(Cards v)
    {
        throw new NotImplementedException();
    }

    public enum Picks
    {
        strongman,
        clown,
        acrobat
    }

    // strongman beats clown
    // clown beats acrobat
    // acrobat beats strongman
}
