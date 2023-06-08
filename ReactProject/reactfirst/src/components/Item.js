import React, { Component } from 'react';
import Modal from './Modal';

class Item extends Component {
  state = {
    isModalOpen: false
  };

  openModal = () => {
    this.setState({ isModalOpen: true });
  };

  closeModal = () => {
    this.setState({ isModalOpen: false });
  };

  handleDismiss = (reason) => {
    console.log('Причина увольнения:', reason);
  };

  render() {
    const { item } = this.props;
    const { isModalOpen } = this.state;

    return (
      <div className='item'>
        <img src={`./img/${item.img}`} alt='' />
        <h2>{item.title}</h2>
        <p>{item.desc}</p>
        <div className='add-to-dismissal' onClick={this.openModal}>
          +
        </div>
        <Modal
          isOpen={isModalOpen}
          onClose={this.closeModal}
          onSubmit={this.handleDismiss}
        />
      </div>
    );
  }
}

export default Item;
