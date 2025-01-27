import { Auth } from "@/src/Services/Auth"
import { DropdownMenu } from "@kobalte/core/dropdown-menu"
import { useNavigate } from "@solidjs/router"

const ProfileMenu = ()=>{
  const navigate = useNavigate() 

  function goToProfile(e:MouseEvent){
    navigate("/profile")
  }

  async function logout(e:MouseEvent){
    await Auth.Logout()
    navigate("/")
  }

  return (
    <div >
      <DropdownMenu>
        <DropdownMenu.Trigger>
          <div 
            class="rounded-full h-[3rem] w-[3rem] bg-neutral-600 flex justify-center items-center select-none cursor-pointer text-mono font-bold text-xl text-neutral-200 hover:text-neutral-800 hover:bg-neutral-400">
            <span>
              P
            </span>
          </div>
        </DropdownMenu.Trigger>

        <DropdownMenu.Portal>
          <DropdownMenu.Content class=" flex flex-col gap-2 select-none rounded-[.5rem] py-4 w-[8rem] bg-neutral-600 mt-[.5rem] text-mono text-md text-neutral-200">
            <DropdownMenu.Item class=" hover:bg-neutral-800 text-neutral-200 px-2 cursor-pointer">
              <div onClick={goToProfile}>
                Profile
              </div>
            </DropdownMenu.Item>

            <DropdownMenu.Item class=" hover:bg-neutral-800 text-neutral-200 px-2 cursor-pointer">
              <div onClick={logout}>
                Logout
              </div>

            </DropdownMenu.Item>
          </DropdownMenu.Content>
        </DropdownMenu.Portal>
      </DropdownMenu>
    </div>
  )
}

export default ProfileMenu
