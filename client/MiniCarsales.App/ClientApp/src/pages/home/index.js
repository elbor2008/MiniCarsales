import React, { useState, memo } from 'react';
import { Dropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap';

export default memo(({ history }) => {
  const [dropdownOpen, setDropdownOpen] = useState(false);
  const toggle = () => setDropdownOpen(prevState => !prevState);

  const handleClickDropdownItem = () => {
    history.push('/car');
  };

  return (
    <div className="text-center">
      <h2 className="mb-4">Vehicle Management System</h2>
      <Dropdown isOpen={dropdownOpen} toggle={toggle}>
        <DropdownToggle caret>
          Create Vehicle
        </DropdownToggle>
        <DropdownMenu>
          <DropdownItem onClick={handleClickDropdownItem}>create car</DropdownItem>
        </DropdownMenu>
      </Dropdown>
    </div>
  );
});