import React from "react";
import Header from "./components/Header";
import Footer from "./components/Footer";
import Items from "./components/Items";
import Categories from "./components/Categories";


class App extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      currentItems: [],
      items: [
        {
        id: 1,
        title: 'Иванов Иван Иванович',
        img: 'sss.jpg',
        desc: 'Секретарь',
        },
        {
        id: 2,
        title: 'Андреев Андрей Андреевич',
        img: 'xxx.jpg',
        desc: 'Уборщик',
        },
        {
        id: 3,
        title: 'Сергеев Сергей Сергеевич',
        img: 'ddd.jpg',
        desc: 'Бухгалтер',
        }
      ]
    }
    this.state.currentItems = this.state.items
    this.chooseCategory = this.chooseCategory.bind(this)
  }
  render() {
  return (
    <div className="wrapper">
      <Header />
      <Categories chooseCategory={this.chooseCategory} />
      <Items items={this.state.currentItems} />
      <Footer />
    </div>

  );
  }
  
  chooseCategory(desc) {
    if (desc === 'all') {
      this.setState({currentItems: this.state.items})
      return
    }
    
    
    this.setState({
      currentItems: this.state.items.filter(el => el.desc === desc)
    })
  }
}

export default App;
