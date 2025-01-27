import { session } from "@/src/App"
import Logo from "@/src/Components/Logo"
import { useNavigate } from "@solidjs/router"
import ProfileMenu from "@/src/Components/Navigation/ProfileMenu"
import { Auth } from "@/src/Services/Auth"

const NavBar = ()=>{
  return (
    <div class="h-[5rem] w-full ">
      <div class="px-4 py-2 w-full h-full flex items-center justify-between">
        <div class=" text-mono font-bold text-neutral-200 ">
          <Logo/>
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
      class="rounded-[.5rem] px-2 py-1 bg-neutral-600 flex justify-center items-center select-none cursor-pointer text-mono font-bold text-xl text-neutral-200 hover:text-neutral-800 hover:bg-neutral-400">
      <span>
        Login
      </span>
    </div>
  )
}

export default NavBar
