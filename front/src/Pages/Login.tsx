import { createSignal } from "solid-js";
import { Auth } from "../Services/Api";
import { useNavigate } from "@solidjs/router";
import { session } from "../App";

export const Login = () => {
  return (
  <div class=" h-full flex justify-center items-center">
      <Form/>
  </div>
  )
}

function Form() {
  // Create signals to manage form state
  const [email, setEmail] = createSignal("");
  const [password, setPassword] = createSignal("");
  const [formMessage, setFormMessage] = createSignal("");
  const navigate = useNavigate()

  // Handle form submission
  const handleSubmit = async (event) => {
    event.preventDefault(); // Prevent default form submission

    // Perform validation (you can customize this as needed)
    if (!email() || !password()) {
      setFormMessage("All fields are required.");
      return;
    }

    const auth_message = await Auth.Login(email(),password()) 
    if (auth_message != ""){
      console.log(auth_message)
      return
    }

    try {
      await Auth.Auth()
      navigate("/")
    } catch (err) {
     console.log(err) 
    }
  };

  return (
    <div class="max-w-md mx-auto p-4 text-neutral-200">
      <h2 class="text-2xl font-bold mb-4">Login</h2>
      <form onSubmit={handleSubmit} class="space-y-4">

        <div>
          <label for="email" class="block text-sm font-medium mb-1">Email:</label>
          <input
            id="email"
            type="email"
            value={email()}
            required
            onInput={(e) => setEmail(e.target.value)}
            class="w-full text-neutral-800 p-2 border border-gray-300 rounded"
          />
        </div>

        <div>
          <label for="password" class="block text-sm font-medium mb-1">Password:</label>
          <input
            id="password"
            type="password"
            value={password()}
            required
            onInput={(e) => setPassword(e.target.value)}
            class="w-full p-2 border text-neutral-800 border-gray-300 rounded"
          />
        </div>

        <button
          type="submit"
          class="w-full p-2 bg-blue-500 text-white rounded hover:bg-blue-600"
        >
          Login
        </button>
        
      </form>

     </div>
  );
}


export default Login
