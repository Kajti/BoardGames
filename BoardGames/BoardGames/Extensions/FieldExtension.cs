﻿using BoardGamesShared.Enums;
using BoardGamesShared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoardGames.Extensions
{
    internal static class FieldExtension
    {
	    public static IField InThisSamePosition(this IEnumerable<IField> fieldList, IField field)
	    {
		    return fieldList.FirstOrDefault(f => f.Heigh == field.Heigh && f.Width == field.Width);
	    }

	    public static List<IField> CopyList(this IEnumerable<IField> fieldList)
	    {
		    return fieldList.Select(field => field.Copy()).ToList();
	    }

	    public static IField Copy(this IField field)
	    {
            IField newField = KernelInstance.Get<IField>();
            newField.Pawn = field.Pawn;
            newField.Heigh = field.Heigh;
            newField.Width = field.Width;
            newField.ID = field.ID;

            return newField;
        }
    }
}
