import { Auth } from "@/src/Services/Api"
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
            class="rounded-full h-[3rem] w-[3rem] bg-neutral-600 flex justify-center items-center select-none cursor-pointer text-mono font-bold text-xl bg-neutral-800 text-neutral-200 hover:bg-[var(--accent)]">
            <span>
              P
            </span>
          </div>
        </DropdownMenu.Trigger>

        <DropdownMenu.Portal>
          <DropdownMenu.Content class=" z-20 flex py-4 flex-col gap-[.5rem] select-none rounded-[.5rem] w-[8rem] bg-neutral-800 mt-[.5rem] text-mono text-md text-neutral-200 font-bold overflow-hidden">
            <DropdownMenu.Item class=" hover:text-[var(--accent)] px-4 py-2 cursor-pointer ">
              <div onClick={goToProfile}>
                Profile
              </div>
            </DropdownMenu.Item>

            <DropdownMenu.Item class=" hover:text-[var(--accent)] px-4 py-2 cursor-pointer">
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
