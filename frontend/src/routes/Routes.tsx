
import { createBrowserRouter } from "react-router";
import HomePage from "../pages/home/HomePage";
import RafflePresentationPage from "../pages/raffles/presentation/RafflePresentationPage";
import AuthPage from "../pages/auth/AuthPage";

export default createBrowserRouter([
  {
    path: "/",
    Component:HomePage
  },
  {
    path:"/raffle/:id",
    Component:RafflePresentationPage
  },
  {
    path:"/auth",
    Component:AuthPage
  }
]);
