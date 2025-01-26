import { render } from "solid-js/web";
import { Route, Router, useNavigate } from "@solidjs/router";
import  Home  from "./Pages/Home";
import  Register  from "./Pages/Register";
import  Login  from "./Pages/Login";
import { createSignal, onMount} from "solid-js";
import { UserSession } from "./types";
import NotFound from "./Pages/NotFound";
import Profile from "./Pages/Profile";
import { Auth } from "./Services/Auth";

export const [session,setSession] = createSignal<UserSession>()

export const App = (props) =>{

  const [isLoading, setIsLoading] = createSignal(true);
   onMount(async ()=>{
    if (!!session()){
      setIsLoading(false)
      return
    }
    await Auth.Auth()
    setIsLoading(false)
  })
 
  return (
    <>
      {isLoading()? <div></div>: props.children}
    </>
  )
};

const Guard = (props)=>{
  const navigate = useNavigate()
  if (!session()) {
    navigate("/login",{replace:true})
  }

  return (
    <>
      {props.children}
    </>
  )
}

const TokenAuth = (props)=>{
  const navigate = useNavigate()
  if (!! session()){
    navigate("/",{replace:true})
  }
   return (
    <>
      {!!session()? Home : props.children}
    </>
  )
}

render(
  () => (
    <Router root={App}>
      <Route path="/" component={Home} />
      <Route path="/Register" component={Register} />
      <Route path="" component={Guard} >
        <Route path="/Profile" component={Profile} />
      </Route >
      <Route path="" component={TokenAuth} >
        <Route path="/Login" component={Login} />
      </Route >
      <Route path="*" component={NotFound} />
    </Router>
  ),
  document.getElementById("root")
);
