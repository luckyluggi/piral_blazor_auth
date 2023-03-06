import * as React from 'react';
import { Link } from 'react-router-dom';
import { ComponentsState, ErrorComponentsState, Menu, Notifications, SwitchErrorInfo, MenuItemProps, ExtensionSlot } from 'piral';

export const errors: Partial<ErrorComponentsState> = {
  not_found: () => (
    <div>
      <p className="error">Could not find the requested page. Are you sure it exists?</p>
      <p>
        Go back <Link to="/">to the dashboard</Link>.
      </p>
    </div>
  ),
};

export const layout: Partial<ComponentsState> = {
  ErrorInfo: (props) => (
    <div>
      <h1>Error</h1>
      <SwitchErrorInfo {...props} />
    </div>
  ),
  Layout: ({ children }) => (<div>
    <ExtensionSlot name="Layout.Initializer" />
    <div className="layout layout--default">
      <header>
        <ExtensionSlot name="Layout.Topbar" />
      </header>
      <aside>
        <ExtensionSlot
          name="Layout.Sidebar"
        />
      </aside>
      <main>{children}</main>
    </div> 
  </div>
  )
};
