import NavBar from "../../Components/Navigation/NavBar"

const MainLayout = (props)=>{
  return (
    <div class="h-screen w-full flex flex-col">
      <NavBar/>
      <div class="flex-1 overflow-y-scroll scrollbar-hidden">
        {props.children}
      </div>
    </div>
  )
}




export default MainLayout
