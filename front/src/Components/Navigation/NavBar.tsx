import { session } from "@/src/App"
import Logo from "@/src/Components/Logo"
import { useNavigate } from "@solidjs/router"
import ProfileMenu from "@/src/Components/Navigation/ProfileMenu"

const NavBar = ()=>{
  const navigate = useNavigate()
  function goToHome(e:MouseEvent){
    navigate('/')
  }

  function goToEvents(e:MouseEvent){
    navigate('/Events')
  }

  return (
    <div class="h-[5rem] w-full ">
      <div class="px-4 py-2 w-full h-full flex items-center justify-between">
        <div class="flex gap-2 text-mono font-bold text-neutral-200 ">
          <Logo/>
          <ul id="nav-bar-link" class="flex gap-2 items-center select-none">
            <li onClick={goToHome}>
              <span>Home</span>
            </li>
            <li onClick={goToEvents}>
              <span>Events</span>
            </li>
          </ul>
        </div>
        {
          !!session() ? <ProfileMenu/> : <SignInButton/> 
        }
      </div>
    </div>
  )
}

const SignInButton = ()=>{
  const navigate = useNavigate()

  function login(e:MouseEvent){
    navigate("/login")
  }

  return (
    <div 
      onClick={login} 
      class="rounded-[.5rem] px-2 py-1 bg-neutral-600 flex justify-center items-center select-none cursor-pointer text-mono font-bold text-lg text-neutral-200 hover:bg-[var(--accent)]">
      <span>
        Login
      </span>
    </div>
  )
}

export default NavBar
