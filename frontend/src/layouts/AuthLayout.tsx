
import { Outlet } from "react-router"

function AuthLayout() {
  return (
    <div className="min-h-screen w-full grid grid-cols-1 lg:grid-cols-2">
        <Outlet />
    </div>
  )
}

export default AuthLayout