import { render } from "solid-js/web";
import { Route, Router, useNavigate } from "@solidjs/router";
import Home  from "./Pages/Home";
import Register  from "./Pages/Register";
import Login  from "./Pages/Login";
import { createSignal, onMount} from "solid-js";
import { Role, UserSession } from "./types";
import NotFound from "./Pages/NotFound";
import Profile from "./Pages/Profile";
import Hero from "./Pages/Hero";
import Power from "./Pages/Power";
import Event from "./Pages/Events";
import { Auth } from "./Services/Api";
import Location from "./Pages/Locations";

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

const AdminGuard = (props) => {
  const navigate = useNavigate()

  if (! session() || session().role != Role.Admin ){
    navigate("/",{replace:true})
  }

  return (
  <>
     {props.children} 
  </>
  )
}

render(
  () => (
    <Router root={App}>
      <Route path="/" component={Home} />
      <Route path="/Register" component={Register} />
      <Route path="/Events" component={Event} />

      <Route path="" component={Guard} >
        <Route path="/Profile" component={Profile} />
        <Route path="" component={AdminGuard} >
          <Route path="/Heros" component={Hero} />
          <Route path="/Powers" component={Power} />
          <Route path="/Locations" component={Location} />
        </Route >
      </Route >

      <Route path="" component={TokenAuth} >
        <Route path="/Login" component={Login} />
      </Route >
      <Route path="*" component={NotFound} />
    </Router>
  ),
  document.getElementById("root")
);
