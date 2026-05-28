import "./header.css";

function Header () {
    return(
        <header>
  {/* LOGO */}
  <div className="logo">
    {/* coloca sua imagem ou texto aqui */}
    <h3 style={{ color: "white" }}>LOGO</h3>
  </div>

  {/* SEARCH */}
  <div className="search">
    <input type="text" placeholder="Pesquisar produtos..." />
  </div>


</header>
    );
}

export default Header;