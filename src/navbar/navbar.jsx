import "./navbar.css";

function Navbar() {
  return (
    <nav className="navbar">
      <ul>
        <li><a href="#">Início</a></li>

        <li className="dropdown">
          <a href="#">Cardápio ▾</a>

          <ul className="dropdown-menu">
            <li><a href="#">lanches</a></li>
            <li><a href="#">Bebidas</a></li>
          </ul>
        </li>

        

        <li><a href="#">Contato</a></li>
      </ul>
    </nav>
  );
}

export default Navbar;