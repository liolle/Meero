import { UserSession } from "../types";
import { setSession } from "../App";

export const Auth = {
  Login :async function(email:string,password:string):Promise<string>{
    try {
      const response = await fetch("http://localhost:5086/user/login", {
        credentials: "include",
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          email: email,
          password: password,
        }),
      });

      if(response.ok){return ""}

      return "Invalid credentials"

    } catch (error) {
      return "Connection failed" 
    }
  },
  Register: async function(name:string,email:string,password:string):Promise<string>{
    try {
      const response = await fetch("http://localhost:5086/user/Register", {
        credentials: "include",
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          email: email,
          name:name,
          password: password,
        }),
      });

      const content = await response.json()
      return content.message

    } catch (error) {
      return "Registration failed" 
    }
  },
  Auth: async function():Promise<void>{
     try {
      const response = await fetch("http://localhost:5086/user/Auth", {
        credentials: "include",
        method: "POST",
      });

      const content = await response.json()
      const message = content.message 

      if (response.ok && !message){
        const s = new UserSession(
          content.name,
          +content.role,
          content.id
        ) 
        setSession(s)
      }

    } catch (error) {
      throw error
    }

  }
}
