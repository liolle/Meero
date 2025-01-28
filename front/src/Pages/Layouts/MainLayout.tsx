import NavBar from "../../Components/Navigation/NavBar"

const MainLayout = (props)=>{
  return (
    <div class="h-screen w-full flex flex-col overflow-hidden">
      {
        <NavBar/>
      }
      <div class="">
        {props.children}
      </div>
    </div>
  )
}




export default MainLayout
