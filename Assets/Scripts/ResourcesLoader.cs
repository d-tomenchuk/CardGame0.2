using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoader 
{
   public Theme GetTheme(string Name)
   {  
      
      
      return Resources.Load<Theme>(Name);
   }
   
}
