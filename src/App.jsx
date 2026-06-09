import Header from "./header/header";
import Navbar from "./navbar/navbar";
import Footer from "./footer/footer";

function App() {
  return (
    <>
      <Header />
      <Navbar />

      <main>
        <div className="carousel">
    <img src="/banner1.jpg" alt="" />
    <img src="/banner2.jpg" alt="" />
    <img src="/banner3.jpg" alt="" />
  </div>
      </main>

      <Footer />
    </>
  );
}

export default App;